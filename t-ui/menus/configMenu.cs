using System;
using System.Collections.Generic;

namespace lgsm_mngr.tui.menus{
    class ConfigMenu : IMenu {

        private String menuTitle = "Config Menu";
        private List<String> choiceList = new List<String>{"Read Config","Change Value"};
    }
}