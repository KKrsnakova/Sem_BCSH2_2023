﻿using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {

        public readonly UsersViewModel UsersVM;
        public UsersView()
        {
            InitializeComponent();
            UsersVM = new UsersViewModel();
            DataContext = UsersVM;
        }
    }
}
