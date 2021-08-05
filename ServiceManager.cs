using System;

namespace lgsm_mngr{
    class ServiceManager{

        public String configLocation {get; private set;}
        public String folderLocation {get; private set;}


        //Services list
        public Services.ConnectionManager connectionManager {get;}
        

        public ServiceManager(bool serviceStart=true, String cfgLoc = "user-data/config.ini"){
            setConfigLocation(cfgLoc);
            Console.WriteLine("DEBUG: Service manager started with config \n" + "--Folder: " + folderLocation + "\n--File Path: " + configLocation);
            //Attempt to start up known services
            if(serviceStart){
                connectionManager = new Services.ConnectionManager();
            }
            else Console.WriteLine("DEBUG: Service manager created without starting services");
            
        }

        public void setConfigLocation(String newLocation){
            folderLocation = newLocation.Substring(0,(newLocation.LastIndexOf('/') + 1));
            configLocation = newLocation;
        }


        //TODO: Better use interface implementation
    }
}