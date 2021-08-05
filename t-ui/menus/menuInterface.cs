using System;

namespace lgsm_mngr.tui.menus{

    interface IMenu {
        String menuTitle {get; set;}
        System.Collections.Generic.List<String> choiceList {get; set;}

        abstract void handleMenu();        
    }
}