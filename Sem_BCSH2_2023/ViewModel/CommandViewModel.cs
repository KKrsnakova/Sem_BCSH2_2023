﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class CommandViewModel : ICommand
    {

        //Fields
        private readonly Action<object> executeAction;
        private readonly Predicate<object>? canExecuteAction;
        private Action deleteGoodButton;

        //Constructors
        public CommandViewModel(Action<object> executeAction)
        {
            this.executeAction = executeAction;
            canExecuteAction = null;
        }

        public CommandViewModel(Action deleteGoodButton)
        {
            this.deleteGoodButton = deleteGoodButton;
        }

        public CommandViewModel(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            this.executeAction = executeAction;
            this.canExecuteAction = canExecuteAction;
        }

        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        //Methods
        public bool CanExecute(object parameter)
        {
            return canExecuteAction == null || canExecuteAction(parameter);
        }
        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
    }
}