﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Penny.Models;
using Penny.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace Penny.Droid
{
    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        EditText edtName, edtPrice, edtCity, edtDescription;
        Spinner spinCategory, spinCondition;
        Button btnAddItem;
        ImageButton imgbtnAddImage;
        User user;
        ArrayAdapter categoryAdapter, conditionAdapter;
        string condition, category;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.AddItem);
            base.OnCreate(savedInstanceState);

            var currentUser = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("user"));

            user = currentUser;
            
            edtCity = FindViewById<EditText>(Resource.Id.edtAddItemCity);
            edtName = FindViewById<EditText>(Resource.Id.edtAddItemName);
            edtDescription = FindViewById<EditText>(Resource.Id.edtAddItemDescription);
            edtPrice = FindViewById<EditText>(Resource.Id.edtAddItemPrice);

            btnAddItem = FindViewById<Button>(Resource.Id.btnAddItemSell);
            imgbtnAddImage = FindViewById<ImageButton>(Resource.Id.imgbtnAddItemImage);

            spinCategory = FindViewById<Spinner>(Resource.Id.spinAddItemCategories);
            spinCondition = FindViewById<Spinner>(Resource.Id.spinAddItemCondition);

            spinCategory.ItemSelected += SpinCategory_ItemSelected;
            categoryAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.categories, Android.Resource.Layout.SimpleSpinnerItem);
            categoryAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinCategory.Adapter = categoryAdapter;

            spinCondition.ItemSelected += SpinCondition_ItemSelected;
            conditionAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.conditions, Android.Resource.Layout.SimpleSpinnerItem);
            conditionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinCondition.Adapter = conditionAdapter;

            btnAddItem.Click += BtnAddItem_Click;
            imgbtnAddImage.Click += ImgbtnAddImage_Click;

            Toast.MakeText(this, user.Name , ToastLength.Long).Show();
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
                Toast.MakeText(this, "Item added", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Item failed", ToastLength.Long).Show();
            }
        }
    }
}