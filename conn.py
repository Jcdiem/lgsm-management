import fabric as fab


class ConnectionHandler:

    def __init__(self, host, user=None, port=None):
        self.con = fab.Connection(host, user, port)
        print('Connection created')

    def run(self, cmd):
        result = self.con.run(cmd)
        print('DEBUG: Command run \nCommand: ' + cmd + '\nResult: ' + result)
        return result
