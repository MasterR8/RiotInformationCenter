using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MvvmCommon
{
    // Die ursprüngliche Implementierung von ObservableObject kommt aus
    // Prism (Microsoft.Practices.Composite.Presentation)
    // http://stackoverflow.com/a/10093257/33311
    //
    // Dies ist eine Variante davon.
    [Serializable]
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Weil die Klasse ViewModel von INotifyPropertyChanged erbt, weiss die WPF, dass 
        /// die Klasse ein PropertyChangedEventHandler mit dem Namen PropertyChanged gibt. 
        /// Daher muss das Objekt PropertyChanged heissen.
        /// Die WPF registriet sich auf diesem Event automatisch.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Dank CallerMemverName, weiss die WPF, welches Property die
        /// Methode aufgerufen hat und gibt das Property der Methode mit. Die Methode liest dann
        /// die neuen Daten aus dem sich geänderten Property aus und aktuallisiert das GUI.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Wird manuell ausgeführt und führt dann OnPropertyChanged aus.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            VerifyPropertyName(propertyName);
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Warnt den Compiler, falls es zum spezifizierten Namen kein Property im Objekt existiert.
        /// Diese Methode ist nur für Debug Build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Sicherstellen, dass der Proterty Name auf dem Objekt exisiert  
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                Debug.Fail("Invalid property name: " + propertyName);
            }
        }
    }
}
