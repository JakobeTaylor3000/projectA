//============================================================================
// PendSim.cs : Defines derived class for simulating a simple pendulum.
//============================================================================
using System;

public class PendSim : Simulator
{
    double L;      // pendulum length
    double L0;   // spring natural length
    double k; // spring constant
    double m; // mass of the pendulum bob
    public PendSim() : base(6)
    {
       
// Set default initial conditions
x[0] =-0.7; // initial x position
x[1] =0; // initial x velocity
x[2] =-0.2; // initial y position
x[3] =0;// initial y velocity
x[4] =0.5;// initial z position
x[5] =0.9; // initial z velocity

L=1;    // Set default parameters
L0=0.9; // default spring natural length
k=90.0; // default spring constant
m=1.4; // default mass of the pendulum bob
g=9.81;
        SetRHSFunc(RHSFuncPendulum);
    }

    //----------------------------------------------------
    // RHSFuncPendulum
    //----------------------------------------------------
    private void RHSFuncPendulum(double[] xx,
        double t, double[] ff)
    {
        L = Math.Sqrt(xx[0]*xx[0] + xx[2]*xx[2] + xx[4]*xx[4]);

        ff[0] =xx[1];
        ff[1] =((-k*(L-L0) /L) *xx[0])/m;
        ff[2] =xx[3];
        ff[3] =(((-k*(L-L0) /L) *xx[2])/m)-g;
        ff[4] =xx[5];
        ff[5] =((-k*(L-L0) /L) *xx[4])/m;

        //ff[0] = ff[1] = ff[2] = ff[3] =ff[4] = ff[5] = 0.0;
    }

    //--------------------------------------------------------------------
    // Getters
    //--------------------------------------------------------------------
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





public double KE
{
get{
return(0.5 *m *(x[1]*x[1] + x[3]*x[3] + x[5]*x[5]));
}
}
public double PE
{
get{
return((m*g*x[2]) + (0.5* k * (L-L0)*(L-L0)));
}
}
public double TotalE
{
get{
return(KE+PE);
}
}

}