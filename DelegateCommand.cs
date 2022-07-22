using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmDemo
{
	public class DelegateCommand : ICommand
	{
		// event execute
		public event EventHandler? CanExecuteChanged;

		// Properties
		readonly Predicate<object> canExecute;
		readonly Action<object> execute;

		//Construtors
		public DelegateCommand(Predicate<object> canExecute, Action<object> execute) =>
			(this.execute, this.canExecute)= (execute, canExecute);

		public DelegateCommand(Action<object> execute) : this(null, execute) { }


		public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		public bool CanExecute(object? parameter) => this.canExecute?.Invoke(parameter) ?? true;

		public void Execute(object? parameter) => this.execute?.Invoke(parameter);
	}
}
