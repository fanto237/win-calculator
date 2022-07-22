using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmDemo
{
	internal class CalculatorViewModel : BaseViewModel
	{
		private double currValue;
		private double lastValue;
		private string operation;
		public double CurrentValue
		{
			get => currValue; set
			{
				if (currValue != value)
				{
					currValue = value;
					this.RaisePropertyChanged();
				}
			}
		}
		public CalculatorViewModel()
		{
			this.NumberCommand = new DelegateCommand((value) =>
			{
				int val = int.Parse((string)value);
				this.CurrentValue = this.CurrentValue * 10 + val;
			});

			this.OperatorCommand = new DelegateCommand((op) =>
			{
				string tmp = (string)op;
				if (tmp.Equals("="))
				{
					switch (operation)
					{
						case "+":
							CurrentValue += lastValue;
							break;
						case "-":
							CurrentValue = lastValue - currValue;
							break;
						case "/":
							if (currValue != 0)
								CurrentValue = lastValue / currValue;
							else
								MessageBox.Show("Division by 0 isn't possible", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
							break;
						case "*":
							CurrentValue *= lastValue;
							break;
					}
				}
				else if (tmp.Equals("C"))
				{
					CurrentValue = 0;
				}
				else
				{
					operation = tmp;
					lastValue = CurrentValue;
					CurrentValue = 0;
				}
			});
		}

		public DelegateCommand NumberCommand { get; set; }
		public DelegateCommand OperatorCommand { get; set; }
	}
}
