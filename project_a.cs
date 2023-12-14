using Godot;
using System;

public partial class project_a : Node3D
{
MeshInstance3D anchor;
MeshInstance3D ball;
SpringModel spring;
PendSim pend;
Label KELabel;
Label PELabel;
Label TotLabel;

double xA, yA, zA;// coords of anchor
float length;// length of pendulum
float length0;
double angle;// pendulum angle
double angleInit;// initial pendulum angle
double time;

Vector3 endA; //end point of anchor
Vector3 endB; // end point for pendulum bob

 
public override void _Ready()
{
GD.Print("Hello MEE 381 in Godot!");
xA =0.0; yA =1.2; zA =0.0;
anchor = GetNode<MeshInstance3D>("Anchor");
ball = GetNode<MeshInstance3D>("Ball1");
spring = GetNode<SpringModel>("SpringModel");
endA = new Vector3((float)xA, (float)yA, (float)zA);
anchor.Position  = endA;
length0=length =0.9f;
spring.GenMesh(0.05f, 0.015f, length, 6.0f, 62);

KELabel = GetNode<Label>("KELabel");
PELabel = GetNode<Label>("PELabel");
TotLabel = GetNode<Label>("TotLabel");





pend = new PendSim();
//GD.Print(pend.X_Position);

 

angleInit = Mathf.DegToRad(60.0); 
float angleF = (float)angleInit;


endB.X = endA.X + length*Mathf.Sin(angleF);
endB.Y = endA.Y + length*Mathf.Cos(angleF);
endB.Z = endA.Z;
PlacePendulum(endB);



time =0.0;
} 
// Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _Process(double delta)
{
// float angleF = (float)Math.Sin(3.0 * time);
// length = length0 + 0.3f*(float)Math.Cos(5.0f * time);

//GD.Print(pend.X_Position);
//GD.Print(pend.Y_Position);
//GD.Print(pend.Z_Position);












endB.X=(float)pend.X_Position;
endB.Y=(float)pend.Y_Position;
endB.Z=(float)pend.Z_Position;

PlacePendulum(endB);
time += delta;



KELabel.Text = "Kinetic Energy: " + pend.KE.ToString("0.00");
PELabel.Text = "Potential Energy: " + pend.PE.ToString("0.00");
TotLabel.Text = "Total Energy: " + pend.TotalE.ToString("0.00");



}


public override void _PhysicsProcess(double delta)
{


base._PhysicsProcess(delta);
pend.StepRK2(time, delta);



}


private void PlacePendulum(Vector3 endB)
{
spring.PlaceEndPoints(endA, endB);
ball.Position = endB;

}
} 

