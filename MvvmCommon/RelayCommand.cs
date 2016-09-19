using System;
using System.Windows.Input;

namespace MvvmCommon
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Dieses Event wird von der WPF aufgerufen. Der CommandManager weiss, wann er das CanExecute ausführen muss.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            // https://joshsmithonwpf.wordpress.com/2008/06/17/allowing-commandmanager-to-query-your-icommand-objects/
            // http://stackoverflow.com/questions/6634777/what-is-the-actual-task-of-canexecutechanged-and-commandmanager-requerysuggested

            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Action sowie Func sind Delegaten, welche Methoden mit bestimmter Signatur erwarten.
        private readonly Action methodToExecute;
        private readonly Func<bool> canExecuteEvaluator;

        /// <summary>
        /// Wir geben dem Konstruktor die Methode welche ausgeführt werden soll, sowie die Methode
        /// um herauszufinden, ob canExecute true oder false sein soll.
        /// 
        /// Bsp: RelayCommand relayCommand = new RelayCommand(auszufuehrendeMethode, ueberpruefendeMethode);
        /// </summary>
        /// <param name="methodToExecute">Diese Methode wird ausgeführt</param>
        /// <param name="canExecuteEvaluator">Diese Methode prüft ob canExecute true oder flase ist</param>
        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator) 
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        /// <summary>
        /// Der zweite Konstruktor ist dafür, wenn man keine Methode zur überprüfung für CanExecute mitgegeben hat.
        /// In diesem Fall wird der normale Konstruktor aufgerufen und es wird null als prüfende Methode mitgegeben.
        /// </summary>
        /// <param name="methodToExecute"></param>
        public RelayCommand(Action methodToExecute) : this(methodToExecute, null)
        {
            // empty
        }

        /// <summary>
        /// Diese Methode wird von dem CommandManager aufgerufen und überprüft, ob das Command ausgeführt werden kann.
        /// Wenn in dem Func-Delegaten canExecuteEvaluator null steht, wird true zurückgegeben.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
                return true;
            
            bool result = this.canExecuteEvaluator.Invoke();
            return result;
        }

        /// <summary>
        /// Diese Methode wird von der WPF aufgerufen, insofern CanExecute true zurückgiebt.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke();
        }

    }
}
