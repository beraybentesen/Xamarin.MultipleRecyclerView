using System;
using Android.OS;
using Android.Views;

namespace MultipleRecyclerView
{
	public class RecyclerViewFragment : Android.Support.V4.App.Fragment
	{
		readonly Func<LayoutInflater, ViewGroup, Bundle, View> view;

		public RecyclerViewFragment(Func<LayoutInflater, ViewGroup, Bundle, View> view)
		{
			this.view = view;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			return view(inflater, container, savedInstanceState);
		}
	}
}
