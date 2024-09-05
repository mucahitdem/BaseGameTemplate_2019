using Scripts.ServiceLocatorModule;

namespace Scripts.UpdateManagement
{
    public static class UpdateManagerRegisterer
    {
        private static UpdateManager UpdateManager
        {
            get
            {
                if (s_updateManager == null)
                    s_updateManager = ServiceLocator.Instance.GetService<UpdateManager>();

                return s_updateManager;
            }
            set => s_updateManager = value;
        }

        private static UpdateManager s_updateManager;


        public static void ModifyRegisterState(IUpdate update, bool startRegister)
        {
            if (UpdateManager == null)
                UpdateManager = ServiceLocator.Instance.GetService<UpdateManager>();
            if(startRegister)
                UpdateManager.Register(update);
            else
                UpdateManager.Unregister(update);
        }
    }
}