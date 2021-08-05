using System;

namespace lgsm_mngr{
    class ServiceManager{


        //Services list
        

        public ServiceManager(bool serviceStart=true){
            //Attempt to start up known services
            if(serviceStart){
                // configMana
            }
            else Console.WriteLine("DEBUG: Service manager created without starting services");            
            
        }        
    }
}