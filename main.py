import tkinter as tk
import interface
import conn


def main():
    window = interface.Window(500, 400)
    window.mainLoop()
    session = conn.ConnectionHandler('localhost')
    print(session.run('whoami'))


if __name__ == '__main__':
    main()
