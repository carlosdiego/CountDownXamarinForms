using System;
using System.Threading;
using Xamarin.Forms;

/// <summary>
/// Author: Carlos Diego - 14/04/2020
/// </summary>
/// 
namespace CountDownXamarinForms.Services
{
    public class CountDown
    {
        /// <summary>
        /// Cancel CountDown
        /// </summary>
        private static CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        /// Progress
        /// </summary>
        private double countProgress;

        /// <summary>
        /// CountDown Timer
        /// </summary>
        /// <param name="TotalTime">Seconds</param>
        /// <param name="Interval">Milliseconds</param>
        /// <param name="_callbackProgress">Callback method update progress</param>
        /// <param name="_callbackEndTime">Callback method finish</param>
        public CountDown(TimeSpan TotalTime, TimeSpan Interval, Action<double> _callbackProgress, Action _callbackEndTime)
        {
            double step = Interval.TotalMilliseconds / TotalTime.TotalMilliseconds;

            _cancellationTokenSource = new CancellationTokenSource();

            Device.StartTimer(Interval, () =>
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    return false;
                }

                if (countProgress < 1)
                {
                    Device.BeginInvokeOnMainThread(() => _callbackProgress.Invoke(countProgress += step));
                    return true;
                }
                else
                {
                    _callbackEndTime.Invoke();
                    return false;
                }

            });

        }

        /// <summary>
        /// Adds progress percentage.
        /// </summary>
        /// <param name="_countProgress">double ex.: 0.10 = 10%, 0.50 = 50%, 1.00 = 100%</param>
        public void AddCountProgress(double _countProgress)
        {
            this.countProgress -= _countProgress;
        }

        /// <summary>
        /// Stop CountDown
        /// </summary>
        public void CountDownStop()
        {
            Interlocked.Exchange(ref _cancellationTokenSource, new CancellationTokenSource()).Cancel();
        }
    }
}
