using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // 値が一緒だったら何もしない
        // 値が違ったら Property に通知、変更
        protected bool SetProperty<T>(ref T field, 
            T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
            return true;
        }

        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
