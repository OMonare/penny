using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Penny.Models;
using Penny.Repositories;

namespace Penny.Droid
{
    public class SellItemFragment : Android.Support.V4.App.Fragment
    {
        EditText edtName, edtPrice, edtCity, edtDescription;
        Spinner spinCategory, spinCondition;
        Button btnAddItem;
        ImageButton imgbtnAddImage;
        User user;
        ArrayAdapter categoryAdapter, conditionAdapter;
        string condition, category;
        public override void OnCreate(Bundle savedInstanceState)
        {
           // super.onCreate(savedInstanceState);
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public SellItemFragment(User user)
        {
            this.user = user;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            spinCategory.ItemSelected += SpinCategory_ItemSelected;
            categoryAdapter = ArrayAdapter.CreateFromResource(Activity, Resource.Array.categories, Android.Resource.Layout.SimpleSpinnerItem);
            categoryAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinCategory.Adapter = categoryAdapter;

            spinCondition.ItemSelected += SpinCondition_ItemSelected;
            conditionAdapter = ArrayAdapter.CreateFromResource(Activity, Resource.Array.conditions, Android.Resource.Layout.SimpleSpinnerItem);
            conditionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinCondition.Adapter = conditionAdapter;

            Toast.MakeText(Activity, user.Name, ToastLength.Long).Show();

            OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             View rootView = inflater.Inflate(Resource.Layout.AddItem, container, false);

            edtCity = rootView.FindViewById<EditText>(Resource.Id.edtAddItemCity);
            edtName = rootView.FindViewById<EditText>(Resource.Id.edtAddItemName);
            edtDescription = rootView.FindViewById<EditText>(Resource.Id.edtAddItemDescription);
            edtPrice = rootView.FindViewById<EditText>(Resource.Id.edtAddItemPrice);

            btnAddItem = rootView.FindViewById<Button>(Resource.Id.btnAddItemSell);
            imgbtnAddImage = rootView.FindViewById<ImageButton>(Resource.Id.imgbtnAddItemImage);

            spinCategory = rootView.FindViewById<Spinner>(Resource.Id.spinAddItemCategories);
            spinCondition = rootView.FindViewById<Spinner>(Resource.Id.spinAddItemCondition);

           

            btnAddItem.Click += BtnAddItem_Click;
            imgbtnAddImage.Click += ImgbtnAddImage_Click;

            

            return rootView;


        }

        private void SpinCondition_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            condition = (string)spinner.GetItemAtPosition(e.Position);
        }

        private void SpinCategory_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            category = (string)spinner.GetItemAtPosition(e.Position);
        }

        private void ImgbtnAddImage_Click(object sender, EventArgs e)
        {

        }

        private async void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (await ItemRepo.AddItem(edtName.Text, category, Double.Parse(edtPrice.Text), edtCity.Text, user.Id, condition, edtDescription.Text, "example.jpg"))
            {
                Toast.MakeText(Activity, "Item added", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(Activity, "Item failed", ToastLength.Long).Show();
            }
        }
    }
}