using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ntree.Data.Entity;
using Ntree.Domain.Model.DataModel;

namespace Ntree.UI
{
	public partial class Start : Form
	{
		private readonly DataContext _dataContext;
		private readonly AppStart _appStart;
		public Start()
		{
			_appStart = new AppStart();
			_appStart.ConfigureAuth();
			_dataContext = new DataContext();
			InitializeComponent();
		}

		private void startBtn_Click(object sender, EventArgs e)
		{
			var users = GetUsers();
		}

		private List<User> GetUsers()
		{
			return _dataContext.GetAllUsers();
		}
	}
}
