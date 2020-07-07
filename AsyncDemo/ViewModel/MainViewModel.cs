using AsyncDemo.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncDemo.ViewModel
{
    /// <summary>
    /// View model for the main window
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        private readonly Results results;

        private string _output;
        /// <summary>
        /// The output of results
        /// </summary>
        public string Output
        {
            get => _output;
            set
            {
                if (_output != value)
                {
                    _output = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        /// <summary>
        /// Contruct a new MainViewModel
        /// </summary>
        public MainViewModel()
        {
            results = new Results();
        }

        #region Commands

        /// <summary>
        /// Get results
        /// </summary>
        public ICommand GetResultsCmd => new RelayCommand<object>(x => GetResults());

        public ICommand GetResultsAsyncCmd => new RelayCommand<object>(async x => await GetResultsAsync());

        /// <summary>
        /// Get results asynchronously, in parallel
        /// </summary>
        public ICommand GetResultsParallelAsyncCmd => new RelayCommand<object>(async x => await GetResultsParallelAsync());

        #endregion

        #region Methods

        /// <summary>
        /// Get results
        /// </summary>
        private void GetResults()
        {
            Output = $"Sync results{Environment.NewLine}";
            var timer = Stopwatch.StartNew();

            var output = results.GetResults();

            foreach (var result in output)
            {
                Output += result.ToString();
                Output += Environment.NewLine;
            }

            timer.Stop();
            Output += $"Time: {timer.ElapsedMilliseconds}ms";
        }

        public async Task GetResultsAsync()
        {
            Output = $"Async results{Environment.NewLine}";
            var timer = Stopwatch.StartNew();

            var output = await results.GetResultsAsync();

            foreach (var result in output)
            {
                Output += result.ToString();
                Output += Environment.NewLine;
            }

            timer.Stop();
            Output += $"Time: {timer.ElapsedMilliseconds}ms";
        }

        /// <summary>
        /// Get results asynchronously, in parallel
        /// </summary>
        /// <returns> A task </returns>
        private async Task GetResultsParallelAsync()
        {
            Output = $"Parallel async results{Environment.NewLine}";
            var timer = Stopwatch.StartNew();

            var output = await results.GetResultsParallelAsync();

            foreach (var result in output)
            {
                Output += result.ToString();
                Output += Environment.NewLine;
            }

            timer.Stop();
            Output += $"Time: {timer.ElapsedMilliseconds}ms";
        }

        #endregion
    }
}