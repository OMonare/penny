using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Penny.Models;
using Penny.Repositories;

namespace Penny.Droid
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : FragmentActivity
    {
        TabLayout tabLayout;
        User currentUser;
        IList<Item> items;
        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.Tabs);

            base.OnCreate(savedInstanceState);

            // Create your application here
            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            tabLayout.TabSelected += TabLayout_TabSelected;
            currentUser = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("user"));
            items = await ItemRepo.GetLocalItemsAsync(currentUser.City);
            
  
            fragmentNavigate(new BuyItemFragment(currentUser, items));

        }

        private async void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch(e.Tab.Position)
            { 
                case 0:
                    items = await ItemRepo.GetLocalItemsAsync(currentUser.City);
                    fragmentNavigate(new BuyItemFragment(currentUser, items));
                    break;

                case 1:
                    items = await ItemRepo.GetCurrentUsersItemsAsync(currentUser.Id);
                    fragmentNavigate(new ViewItemsFragment(currentUser, items));
                    break;
            }
        }

        private void fragmentNavigate(Android.Support.V4.App.Fragment fragment)
        {        

            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }

    }
}