﻿using BCG_UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BCG_UI.ViewModel
{

	public abstract class DetailViewModelBase : ViewModelBase, IDetailedViewModel
	{
		private bool _hasChanges;
		protected readonly IEventAggregator EventAggregator;

		public DetailViewModelBase(IEventAggregator eventAggregator)
		{
			EventAggregator = eventAggregator;
			SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
			DeleteCommand = new DelegateCommand(OnDeleteExecute);
		}

		public abstract Task LoadAsync(int? id);

		public ICommand SaveCommand { get; private set; }

		public ICommand DeleteCommand { get; private set; }

		protected abstract void OnDeleteExecute();
		protected abstract bool OnSaveCanExecute();
		protected abstract void OnSaveExecute();

		public bool HasChanges
		{
			get { return _hasChanges; }
			set
			{
				if (_hasChanges != value)
				{
					_hasChanges = value;
					OnPropertyChanged();
					((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
				}
			}
		}

		protected virtual void RaiseDetailDeletedEvent(int modelId)
		{
			EventAggregator.GetEvent<AfterDetailDeletedEvent>().Publish(new AfterDetailDeletedEventArgs
			{
				Id = modelId,
				ViewModelName = this.GetType().Name
			});
		}

		protected virtual void RaiseDetailSavedEvent(int modelId, string displayMember)
		{
			EventAggregator.GetEvent<AfterDetailSavedEvent>().Publish(new AfterDetailSavedEventArgs
			{
				Id = modelId,
				DisplayMember = displayMember,
				ViewModelName = this.GetType().Name
			});
		}
	}
	}
