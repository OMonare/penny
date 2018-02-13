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
using Java.Util.Zip;
using Penny.Models;

namespace Penny.Droid
{
    public class BuyItemFragment : Android.Support.V4.App.Fragment
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
            base.OnCreate(savedInstanceState);

            // Create your fragment here
           
            

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment


             View rootview = inflater.Inflate(Resource.Layout.BuyItem, container, false);

            return rootview;



            
        }
    }
}