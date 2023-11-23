using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OvertimeTracker.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace OvertimeTracker.ViewModels
{
	[QueryProperty(nameof(OvertimeList), "Data")]
	public partial class AddViewModel : ObservableObject
	{
		[ObservableProperty] public DateTime date = DateTime.Now;

		[ObservableProperty] public TimeSpan start;

		[ObservableProperty] public TimeSpan end;

		[ObservableProperty] public float multiplier = 1;

		[ObservableProperty] public float overtime;

		[ObservableProperty] ObservableCollection<OvertimeData> overtimeList;

		[RelayCommand]
		public async Task Add()
		{
			OvertimeData overtimeData = new OvertimeData()
			{
				Date = DateOnly.FromDateTime(Date),
				Start = TimeOnly.FromTimeSpan(Start),
				End = TimeOnly.FromTimeSpan(End),
				Overtime = Overtime,
			};
			OvertimeList.Add(overtimeData);

			using FileStream fs = File.Create(Path.Combine(FileSystem.Current.AppDataDirectory, "data.json"));
			System.Diagnostics.Debug.WriteLine(FileSystem.Current.AppDataDirectory);
			JsonSerializer.SerializeAsync(fs, OvertimeList);

			await Shell.Current.GoToAsync("..");
		}

		partial void OnStartChanged(TimeSpan oldValue, TimeSpan newValue)
		{
			if (oldValue != newValue && End > newValue)
			{
				Overtime = (float)((End - newValue).TotalMinutes / 60.0f * Multiplier);
			}
		}

		partial void OnEndChanged(TimeSpan oldValue, TimeSpan newValue)
		{
			if (oldValue != newValue && newValue > Start)
			{
				Overtime = (float)((newValue - Start).TotalMinutes / 60.0f) * Multiplier;
			}
		}

		partial void OnMultiplierChanged(float oldValue, float newValue)
		{
			if (oldValue != newValue && newValue >= 0 && newValue < float.MaxValue)
			{
				Overtime = (float)((End - Start).TotalMinutes / 60.0f) * Multiplier;
			}
		}
	}
}
