using System;
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.AddItem);
            base.OnCreate(savedInstanceState);

            edtCity = FindViewById<EditText>(Resource.Id.edtAddItemCity);
            edtName = FindViewById<EditText>(Resource.Id.edtAddItemName);
            edtDescription = FindViewById<EditText>(Resource.Id.edtAddItemDescription);
            edtPrice = FindViewById<EditText>(Resource.Id.edtAddItemPrice);

            btnAddItem = FindViewById<Button>(Resource.Id.btnAddItemSell);
            imgbtnAddImage = FindViewById<ImageButton>(Resource.Id.imgbtnAddItemImage);

            spinCategory = FindViewById<Spinner>(Resource.Id.spinAddItemCategories);
            spinCondition = FindViewById<Spinner>(Resource.Id.spinAddItemCondition);

            btnAddItem.Click += BtnAddItem_Click;
            imgbtnAddImage.Click += ImgbtnAddImage_Click;
         }

        private void ImgbtnAddImage_Click(object sender, EventArgs e)
        {           
            
        }

        private async void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (await ItemRepo.AddItem(edtName.Text, "Furniture", Double.Parse(edtPrice.Text), edtCity.Text, new Guid(), "New", edtDescription.Text, "example.jpg"))
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