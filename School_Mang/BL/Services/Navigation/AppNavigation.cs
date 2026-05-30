using System;
using System.Linq;
using System.Windows.Forms;

namespace School_Mang.BL.Services
{
    public class AppNavigation
    {
        private static readonly Lazy<AppNavigation> _instance =
            new Lazy<AppNavigation>(() => new AppNavigation());

        public static AppNavigation Instance => _instance.Value;

        private NavigationContext _context;
        private Form _owner;

        public event Action<NavigationContext> ContextChanged;

        public NavigationContext GetContext()
        {
            return _context;
        }

        private AppNavigation()
        {
            // default context
            _context = new NavigationContext();
        }

        // =========================
        // Attach Navigation
        // =========================
        private void AttachNavigation(Form form, NavigationContext context)
        {
            if (form is INavigationAware aware)
                aware.SetNavigation(context);

            if (form is INavigationAwareLoaded loaded)
            {
                EventHandler handler = null;
                handler = (s, e) =>
                {
                    form.Shown -= handler;
                    loaded.OnNavigatedTo();
                };

                form.Shown += handler;
            }
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
        // Context (NEW SAFE VERSION)
        // =========================
        public AppNavigation SetContext(Action<NavigationContext> config)
        {
            // 🔥 Always create fresh context per navigation
            _context = new NavigationContext();

            config?.Invoke(_context);

            ContextChanged?.Invoke(_context);

            return this;
        }

        // =========================
        // Generic Show (T)
        // =========================
        public Form Show<T>(
            bool isDialog = true,
            bool useOwner = true
        ) where T : Form, new()
        {
            // 🔥 ensure context exists
            if (_context == null)
                _context = new NavigationContext();

            var existing = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existing != null)
            {
                if (existing.WindowState == FormWindowState.Minimized)
                    existing.WindowState = FormWindowState.Normal;

                if (!existing.Visible)
                    existing.Show();

                existing.BringToFront();
                existing.Focus();

                return existing;
            }

            var form = new T();

            // 🔥 pass context reference (shared for this navigation only)
            var context = _context;

            AttachNavigation(form, context);

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

        // =========================
        // Instance Show
        // =========================
        public void Show(
            Form form,
            bool isDialog = true,
            bool useOwner = true
        )
        {
            var existing = Application.OpenForms
                .Cast<Form>()
                .FirstOrDefault(f => f.GetType() == form.GetType());

            if (existing != null)
            {
                if (existing.WindowState == FormWindowState.Minimized)
                    existing.WindowState = FormWindowState.Normal;

                if (!existing.Visible)
                    existing.Show();

                existing.BringToFront();
                existing.Focus();
                return;
            }

            if (_context == null)
                _context = new NavigationContext();

            var context = _context;

            AttachNavigation(form, context);

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
        // Rest
        public void Reset()
        {
            _context = new NavigationContext();
        }
    }
}