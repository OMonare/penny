using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Util.Zip;
using Penny.Models;
using Penny.Repositories;

namespace Penny.Droid
{
    public class ViewItemsFragment : Android.Support.V4.App.Fragment
    {

        User user;
        IList<Item> items;
        ItemAdapter itemAdapter;
        View parentView;

        public ViewItemsFragment(User user, IList<Item> items)
        {
            this.user = user;
            this.items = items;

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            try
            {

                Toast.MakeText(Activity, items.FirstOrDefault().Name, ToastLength.Long).Show();
            }
            catch
            {
                OnCreate(savedInstanceState);
                Toast.MakeText(Activity, "No items for sale near you", ToastLength.Long).Show();
            }
        }

        public override void OnAttach(Context context)
        {

            //recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            //recyclerView.SetLayoutManager(layoutManager);
            //recyclerView.SetAdapter(itemAdapter);
            base.OnAttach(context);

        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // return base.OnCreateView(inflater, container, savedInstanceState);

            //ListAdapter = new ArrayAdapter<Item>(Activity, Android.Resource.Layout.SimpleListItem2, items.ToList());

            base.OnActivityCreated(savedInstanceState);
            //  parentView = inflater.Inflate(Resource.Layout.Tabs, container, false);
            RecyclerView.LayoutManager layoutManager;

            itemAdapter = new ItemAdapter(items);
            layoutManager = new LinearLayoutManager(Activity);
            View rootView = inflater.Inflate(Resource.Layout.BuyItem, container, false);

            RecyclerView recyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.recyclerView);


            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(itemAdapter);


            return rootView;
        }

    }

   
}