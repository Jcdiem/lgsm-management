using System;

namespace lgsm_mngr.Services{
    interface IService {
        public bool isRunning {get;}
        public void startService();
        public void stopService();
    }
}