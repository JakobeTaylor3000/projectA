
using System;


public class SimPendulum
{
    private double L;
    private double m;
    private double k;
    private double L0;
    private double g;
    int n;
    double[] x;
    double[] xA;
    double[][]f;


//------------------------------
// Constructor
//------------------------------
    public SimPendulum()
{
L= 5; // 
L0=0.9; // default spring natural length
k=90.0; // default spring constant
 m=1.4; // default mass of the pendulum bob
 g=9.81;

    n=6;
    x = new double[n];
    xA = new double[n];
    f = new double[6][];
    f[0] = new double[n];
    f[1] = new double[n];
    f[2] = new double[n];
    f[3] = new double[n];
    f[4] = new double[n];
    f[5] = new double[n];
    
}

//----------------------------------------------------
// StepEuler: completes one Euler step in solving
// equations of motion
//----------------------------------------------------


public void StepEuler(double time, double dt)
{
    int i;

    RHSFuncPendulum(x, time, f[0]);
    for(i=0; i<n; ++i){
        x[i] += f[0][i]*dt;
    }
}

//----------------------------------------------------
// StepEuler: completes one RK2 step in solving
// equations of motion
//----------------------------------------------------

public void StepRk2(double time, double dt)
{
int i;

RHSFuncPendulum(x, time, f[0]);
for(i=0; i<n; ++i){
xA[i] = x[i] + f[0][i]*dt;
}

}



//----------------------------------------------------
// RHSFuncPendulum
//----------------------------------------------------

private void RHSFuncPendulum(double[] xx, double t, double[] ff)
{

ff[0]=xx[1];
ff[1]=(-k*(L-L0)*xx[0]) / (L*m);
ff[2]=xx[3];
ff[3]= ((-k*(L-L0)*xx[0])/(m*L))-g;
ff[4]= xx[5];
ff[5]= (-k * (L-L0) * xx[4])/(m*L);

}


public double X_Position
{
    get{
            return(x[0]);
    }

    set{
        x[0] = value;
    }
}

public double Y_Position
{
    get{
            return(x[1]);
    }

    set{
        x[1] = value;
    }
}

public double Z_Position
{
    get{
            return(x[2]);
    }

    set{
        x[2] = value;
    }
}

public double X_Velocity
{
    get{
            return(x[3]);
    }

    set{
        x[3] = value;
    }
}

public double Y_Velocity
{
    get{
            return(x[4]);
    }

    set{
        x[4] = value;
    }
}

public double Z_Velocity
{
    get{
            return(x[5]);
    }

    set{
        x[5] = value;
    }
}



public void TestFunc()
{
    // Console.WriteLine("Inside TestFunc");
}



}