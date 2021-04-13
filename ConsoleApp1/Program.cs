using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.OpenDocuments.Add(new DocumentViewModel("文档1"));
            mainViewModel.OpenDocuments.Add(new DocumentViewModel("文档2"));
            mainViewModel.OpenDocuments.Add(new DocumentViewModel("文档3"));
            mainViewModel.OpenDocuments.Add(new DocumentViewModel("文档4"));

            mainViewModel.OpenDocuments.First().CloseCommand.Execute().Subscribe();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }

    public class DocumentViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> CloseCommand { get; set; }

        public string Name { get; set; }

        public DocumentViewModel(string name)
        {
            CloseCommand = ReactiveCommand.Create(() => { });
            Name = name;
        }
    }

    public class MainViewModel : ReactiveObject
    {
        public ObservableCollection<DocumentViewModel> OpenDocuments { get; set; }

        public MainViewModel()
        {
            OpenDocuments = new ObservableCollection<DocumentViewModel>();

            OpenDocuments
                .ToObservableChangeSet()
                .AutoRefreshOnObservable(document => document.CloseCommand)
                .Select(_ => WhenAnyDocumentClosed())
                .Switch()
                .Subscribe(x =>
                    OpenDocuments.Remove(x)
                    );

        }

        private IObservable<DocumentViewModel> WhenAnyDocumentClosed()
        {
            var value = OpenDocuments.Select(x => x.CloseCommand.Select(_ => x)).Merge();
            return value;
        }
    }
}
