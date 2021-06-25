import tkinter as tk
# TODO: find out why ttk isn't found through standard import
from tkinter import ttk


class Window:

    def __init__(self, xSize, ySize):
        self.win = tk.Tk()
        # Create the window centered on the screen
        self.win.geometry("{}x{}+{}+{}".format(xSize,
                                               ySize,
                                               int((self.win.winfo_screenwidth()/2)-(xSize/2)),
                                               int((self.win.winfo_screenheight()/2)-(ySize/2))
                                               ))
        # Tk Vars
        self.style = ttk.Style()
        self.header_frame = ttk.Frame(self.win)


        # Styling stuff
        self.win.title('Linux Game Server Management GUI')


        # Actual GUI creation



    def mainLoop(self):
        self.win.mainloop()