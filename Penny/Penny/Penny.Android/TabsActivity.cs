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
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Penny.Models;

namespace Penny.Droid
{
    [Activity(Label = "TabsActivity")]
    public class TabsActivity : FragmentActivity
    {
        TabLayout tabLayout;
        User currentUser;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.Tabs);

            base.OnCreate(savedInstanceState);

            // Create your application here
            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            tabLayout.TabSelected += TabLayout_TabSelected;
            fragmentNavigate(new BuyItemFragment());
            currentUser = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("user"));
            
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch(e.Tab.Position)
            { 
                case 0:
                    fragmentNavigate(new SellItemFragment(currentUser));
                    break;
                case 1:
                    fragmentNavigate(new BuyItemFragment());
                    break;
                case 2:
                    fragmentNavigate(new ProfileFragment());
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