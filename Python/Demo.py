def TestVariableScope():
    #print(a)
    print(TestVariableScope.a)
    TestVariableScope.a=13

def SetVariable():
    a=12
    TestVariableScope.a=12

if __name__=='Demo':
    print('Demo is running')

if __name__ == '__main__':
    SetVariable()
    TestVariableScope()
    b=TestVariableScope
    b()
