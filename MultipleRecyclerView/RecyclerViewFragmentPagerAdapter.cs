using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Java.Lang;

namespace MultipleRecyclerView
{
	public class RecyclerViewFragmentPagerAdapter : FragmentPagerAdapter
	{
		readonly List<Fragment> fragmentList = new List<Fragment>();
		readonly ICharSequence[] titles;

		public RecyclerViewFragmentPagerAdapter(FragmentManager fragmentManager, ICharSequence[] titles) : base(fragmentManager)
		{
			this.titles = titles;
		}

		public override int Count
		{
			get
			{
				return fragmentList.Count;
			}
		}

		public override Fragment GetItem(int position)
		{
			return fragmentList[position];
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return titles[position];
		}

		public void addFragmentView(Func<LayoutInflater, ViewGroup, Bundle, View> fragmentView)
		{
			fragmentList.Add(new RecyclerViewFragment(fragmentView));
		}
	}
}
