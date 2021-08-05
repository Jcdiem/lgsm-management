using System;
using System.Collections.Generic;

namespace lgsm_mngr.tui.menus{
    class ConfigMenu : IMenu {
        public String menuTitle {get;}
        public List<String> choiceList {get;}

        public ConfigMenu(){
            menuTitle = "Config Menu";
            choiceList = new List<String>{"Read Config","Change Value"};            
        }

        public void handleMenu(){
            throw new NotImplementedException("Menu not yet created");
        }
    }
}