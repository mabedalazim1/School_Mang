using System;
using System.Windows.Forms;

namespace School_Mang.BL.Services
{
    public class AppNavigation
    {
        private static readonly Lazy<AppNavigation> _instance =
            new Lazy<AppNavigation>(() => new AppNavigation());

        public static AppNavigation Instance => _instance.Value;

        public static NavigationContext CurrentContext { get; private set; }

        private NavigationContext _context;
        private Form _owner;

        private AppNavigation()
        {
            _context = new NavigationContext();
        }

        // =========================
        // Owner
        // =========================
        public AppNavigation WithOwner(Form owner)
        {
            _owner = owner;
            return this;
        }

        // =========================
        // Context
        // =========================
        public AppNavigation SetContext(Action<NavigationContext> config)
        {
            _context = new NavigationContext();
            config?.Invoke(_context);
            return this;
        }

        // =========================
        // Generic Show (T)
        // isDialog = true  => ShowDialog
        // isDialog = false => Show
        // =========================
        public Form Show<T>(
            bool isDialog = true,
            bool useOwner = true
        ) where T : Form, new()
        {
            try
            {
                CurrentContext = _context;

                var form = new T();

                if (form is INavigationAware aware)
                    aware.SetNavigation(_context);

                if (isDialog)
                {
                    if (useOwner && _owner != null)
                        form.ShowDialog(_owner);
                    else
                        form.ShowDialog();
                }
                else
                {
                    if (useOwner && _owner != null)
                        form.Show(_owner);
                    else
                        form.Show();
                }

                return form;
            }
            finally
            {
                CurrentContext = null;
            }
        }

        // =========================
        // Instance Show (existing form)
        // =========================
        public void Show(
            Form form,
            bool isDialog = true,
            bool useOwner = true
        )
        {
            if (form is INavigationAware aware)
                aware.SetNavigation(_context);

            if (isDialog)
            {
                if (useOwner && _owner != null)
                    form.ShowDialog(_owner);
                else
                    form.ShowDialog();
            }
            else
            {
                if (useOwner && _owner != null)
                    form.Show(_owner);
                else
                    form.Show();
            }
        }
    }
}