using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;

namespace MultipleRecyclerView
{
	public class RecyclerViewAdapter : RecyclerView.Adapter
	{

		public List<RecyclerViewDataModel> dataModelList;
		public Context context;
		public event EventHandler<int> eventHandler;


		public RecyclerViewAdapter(List<RecyclerViewDataModel> dataModelList, Context context)
		{
			this.dataModelList = dataModelList;
			this.context = context;
		}

		public override int ItemCount
		{
			get
			{
				return dataModelList.Count;
			}
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var item = dataModelList[position];

			var viewHolder = holder as RecyclerViewHolder;

			if (holder == viewHolder && viewHolder != null)
			{
				viewHolder.textView.Text = item.someString;

				Glide.With(context).Load(item.imageUrl).Into(viewHolder.imageView);
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RecyclerViewItemLayout, parent, false);

			var viewHolder = new RecyclerViewHolder(view, clickEvent);

			return viewHolder;
		}

		public void clickEvent(int position)
		{
			if (eventHandler != null)
				eventHandler(this, position);	
		}
	}

	public class RecyclerViewHolder : RecyclerView.ViewHolder
	{
		public View view { get; set; }
		public ImageView imageView { get; set; }
		public TextView textView { get; set; }

		public RecyclerViewHolder(View view, Action<int> eventHandler) : base(view)
		{
			this.view = view;
			imageView = view.FindViewById<ImageView>(Resource.Id.imageView);
			textView = view.FindViewById<TextView>(Resource.Id.textView);
			view.Click += (sender, e) => eventHandler(AdapterPosition);
		}
	
	}
}
