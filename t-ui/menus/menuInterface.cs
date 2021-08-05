using System;

namespace lgsm_mngr.tui.menus{

    interface IMenu {
        String menuTitle {get;}
        System.Collections.Generic.List<String> choiceList {get;}

        abstract void handleMenu();        
    }
}