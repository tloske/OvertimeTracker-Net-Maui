using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OvertimeTracker.Models;
using OvertimeTracker.Views;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace OvertimeTracker.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{
		[ObservableProperty] ObservableCollection<OvertimeData> overtimeList = new();

		public MainViewModel()
		{
			LoadData();
		}

		[RelayCommand]
		public async Task Add()
		{
			await Shell.Current.GoToAsync(nameof(AddPage), new Dictionary<string, object> { { "Data", OvertimeList } });
		}

		[RelayCommand]
		public void Delete()
		{

		}

		public async void LoadData()
		{
			string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "data.json");
			if (File.Exists(filePath))
			{
				using FileStream fs = File.OpenRead(filePath);
				OvertimeList = await JsonSerializer.DeserializeAsync<ObservableCollection<OvertimeData>>(fs) ?? new ObservableCollection<OvertimeData>();
			}

		}
	}
}
