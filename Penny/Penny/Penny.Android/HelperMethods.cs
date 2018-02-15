using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Penny.Models;

namespace Penny.Droid
{
    //----------------------------------------------------------------------
    // VIEW HOLDER

    // Implement the ViewHolder pattern: each ViewHolder holds references
    // to the UI components (ImageView and TextView) within the CardView 
    // that is displayed in a row of the RecyclerView:
    public class ItemViewHolder : RecyclerView.ViewHolder
    {
        public TextView Price { get; private set; }
        public TextView Name { get; private set; }
        public TextView Condition { get; private set; }

        // Get references to the views defined in the CardView layout.
        public ItemViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            // Locate and cache view references:
            Price = itemView.FindViewById<TextView>(Resource.Id.txtBuyItemPrice);
            Name = itemView.FindViewById<TextView>(Resource.Id.txtBuyItemName);
            Condition = itemView.FindViewById<TextView>(Resource.Id.txtBuyItemCondition);

            // Detect user clicks on the item view and report which item
            // was clicked (by layout position) to the listener:
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }


    public class ItemAdapter : RecyclerView.Adapter
    {
        // Event handler for item clicks:
        public event EventHandler<int> ItemClick;

        // Underlying data set (a list of items):
        public IList<Item> mItem;

        // Load the adapter with the data set (photo album) at construction time:
        public ItemAdapter(IList<Item> item)
        {
            mItem = item;
        }

        // Create a new item CardView (invoked by the layout manager): 
        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the item:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.ItemCard, parent, false);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            ItemViewHolder itemViewHolder = new ItemViewHolder(itemView, OnClick);
            return itemViewHolder;
        }

        // Fill in the contents of the item card (invoked by the layout manager):
        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ItemViewHolder itemViewHolder = holder as ItemViewHolder;

            // Set the ImageView and TextView in this ViewHolder's CardView 
            // from this position in the item list:
            //itemViewHolder.Image.SetImageResource(mPhotoAlbum[position].PhotoID);

            itemViewHolder.Name.Text = mItem[position].Name;
            itemViewHolder.Price.Text = "R" + mItem[position].Price;
            itemViewHolder.Condition.Text = mItem[position].Condition;
        }

        // Return the number of items available in the item list:
        public override int ItemCount
        {
            get { return mItem.Count(); }
        }

        // Raise an event when the item-click takes place:
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }
}