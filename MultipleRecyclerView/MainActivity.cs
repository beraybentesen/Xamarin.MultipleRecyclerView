using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.View;
using Java.Lang;
using System.Collections.Generic;
using Android.Support.Design.Widget;
using System;
using System.Linq;
using Android.Runtime;

namespace MultipleRecyclerView
{
	[Activity(Theme = "@style/MaterialTheme", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{
		Android.Support.V7.Widget.Toolbar toolbar;
		ViewPager viewPager;
		TabLayout tabLayout;
		RecyclerView recyclerView;
		RecyclerViewAdapter recyclerViewAdapter;
		RecyclerViewFragmentPagerAdapter recyclerViewFragmentPagerAdapter;
		ICharSequence[] titles;
		LinearLayoutManager linearLayoutManager;
		List<RecyclerViewDataModel> dataModelList;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(false);

			tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
			viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

			dataModelList = new List<RecyclerViewDataModel>();

			loadData();

			viewPager.Adapter = recyclerViewFragmentPagerAdapter;
			tabLayout.SetupWithViewPager(viewPager);
		}

		void loadData()
		{
			for (int i = 0; i <= 7; i++)
			{
				dataModelList.Add(new RecyclerViewDataModel
				{
					someString = "SomeString " + i,
					imageUrl = "https://blog.xamarin.com/wp-content/uploads/2015/03/RDXWoY7W_400x400.png"
				});
			}

			var sArray = dataModelList.Select(x => x.someString).ToArray();

			titles = CharSequence.ArrayFromStringArray(sArray);

			recyclerViewFragmentPagerAdapter = new RecyclerViewFragmentPagerAdapter(SupportFragmentManager, titles);

			foreach (var item in dataModelList)
			{
				createFragment(dataModelList);
			}
		}

		void createFragment(List<RecyclerViewDataModel> list)
		{
			recyclerViewFragmentPagerAdapter.addFragmentView((arg1, arg2, arg3) =>
			{

				var view = arg1.Inflate(Resource.Layout.RecyclerViewLayout, arg2, false);

				recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

				linearLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);

				recyclerViewAdapter = new RecyclerViewAdapter(list, this);

				recyclerView.SetLayoutManager(linearLayoutManager);

				recyclerView.SetAdapter(recyclerViewAdapter);

				recyclerViewAdapter.NotifyDataSetChanged();

				recyclerViewAdapter.eventHandler += (sender, e) =>
				{
					// Accessing data from selected item
					var item = list[e];
					Console.WriteLine(item.someString);
				};

				return view;

			});
		}

	}
}

