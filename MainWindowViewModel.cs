using System;

namespace MvvmDemo
{
	internal class MainWindowViewModel : BaseViewModel
	{

		public MainWindowViewModel()
		{
			ClearCommand = new DelegateCommand(
				(o) => !String.IsNullOrEmpty(Name) || !(Age == 0),
				(o) => { this.Name = ""; Age = 0; }
				);

			Name="Lucien";
			Age = 21;

		}

		#region

		public string name;

		public string Name
		{
			get => name; set
			{
				if (name != value)
				{
					name = value;
					this.RaisePropertyChanged();
					this.RaisePropertyChanged(nameof(Salut));
					this.ClearCommand.RaiseCanExecuteChanged();
				}
			}
		}

		public int age;
		public int Age
		{
			get => age; set
			{
				if (age != value)
				{
					age = value;
					this.RaisePropertyChanged();
					this.RaisePropertyChanged(nameof(Salut));
					this.ClearCommand.RaiseCanExecuteChanged();


				}
			}
		}

		public string Salut => $"Salut, {Name}; tu as actuellement {Age}";



		#endregion

		public DelegateCommand ClearCommand { get; set; }
	}
}
