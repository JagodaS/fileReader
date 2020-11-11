using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T item, T value, bool coerce = false, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(item, value) && !coerce) return;
            item = value;
            RaisePropertyChanged(propertyName);
        }


        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public virtual void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
    }

    public class CommandAction : ICommand
    {
        private readonly Action<object> methodToExecute;

        private readonly Func<object, bool> canExecuteEvaluator;

        public CommandAction(Action<object> methodToExecute, Func<object, bool> canExecuteEvaluator = null)
        {
            if (methodToExecute == null)
                throw new ArgumentNullException(nameof(methodToExecute));
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return canExecuteEvaluator?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            methodToExecute?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecuteEvaluator != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecuteEvaluator != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
    }
}
