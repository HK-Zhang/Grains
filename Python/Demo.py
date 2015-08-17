def TestVariableScope():
    #print(a)
    print(TestVariableScope.a)
    TestVariableScope.a=13

from sklearn import linear_model
clf = linear_model.LinearRegression()
clf.fit([[1],[2],[5],[10],[25],[50],[100],[250]],[21.90593302,24.68242796,33.00913072,46.87769512,88.53902951,161.2203224,308.2521436,749.764916])
clf.coef_
clf.intercept_

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
