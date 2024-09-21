using Hasher.Avalonia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasher.Avalonia.ViewModels
{
    public class FileDataViewModel : ViewModelBase
    {
        public FileDataViewModel() { }

		public FileDataViewModel(FileData fileData)
		{
			fileName = fileData.Name;
			fileSize = fileData.Size;
			isSelected = fileData.IsSelected;
		}

		private string fileName;

		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}

		private double fileSize;

		public double FileSize
		{
			get { return fileSize; }
			set { fileSize = value; }
		}

		private bool isSelected;

		public bool IsSelected
		{
			get { return isSelected; }
			set { isSelected = value; }
		}

	}
}
