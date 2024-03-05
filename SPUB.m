load('date_robert.mat')
%date initiale
m=3;
m2=10;
N=200;
a=-0.7;
b=0.7;

%spab pentru m=3
u1=spabRobert(N,m,a,b);
%spab pentru m=10
u2=spabRobert(N,m2,a,b);
%generare semnal U 
U=[zeros(1,10),u1',zeros(1,30),u2',zeros(1,40),0.4*ones(1,70)];
figure
plot (u)

figure;
plot(u1)
title("SPAB m=3")
figure;
plot(u2)
title("SPAB m=10")

figure;
plot(vel)

na=4;
nb=8;
%u si vel luate din vectori pt fiecare
u_id_3=u(51:249);
y_id_3=vel(51:249);
u_id_10=u(300:498);
y_id_10=vel(300:498);
u_val= u(551:end);
y_val= vel(551:end);

%functie iddata
T=t(2)-t(1);
id_3=iddata(y_id_3',u_id_3',T);
id_10=iddata(y_id_10',u_id_10',T);
val=iddata(y_val',u_val',T);

%arx pentru m=3
arx1 = arx(id_3,[na,nb,1]);
%arx pentru m=10 
arx2 = arx(id_10,[na,nb,1]);
%arx validare 
arx3 = arx(val,[na,nb,1]);

%simulare simulari
yid_3 = lsim(arx1,u_id_3);
yid_10 = lsim(arx2,u_id_10);
yval_3 = lsim(arx1,u_val);
yval_10= lsim(arx2,u_val);
yval = lsim(arx3,u_val);

figure;
plot(y_val);
hold on;
plot(yval_10);
hold on;
plot(yval_3);

%functia pentru spab curs 
function y=spabRobert(N,m,a,b)
m=3;
aa=zeros(m);
if m==3
    aa(1)=1;
    aa(3)=1;
elseif m==4
    aa(1)=1;
    aa(4)=1;
elseif m==5
    aa(2)=1;
    aa(5)=1;
elseif m==6
    aa(1)=1;
    aa(6)=1;
elseif m==7
    aa(1)=1;
    aa(6)=1;
elseif m==8
    aa(1)=1;
    aa(2)=1;
    aa(7)=1;
    aa(8)=1;
elseif m==9
    aa(4)=1;
    aa(9)=1;
elseif m==10
    aa(3)=1;
    aa(10)=1;
end
for d=1:m 
 D(1,d)=aa(d);
end
for i=2:m
for j=1:m
if i-j==1
    D(i,j)=1;
    else
    D(i,j)=0;
end
end
end
x=ones(1,m);
for i = 2:100
    x(i,1)=mod(D(1,:)*x(i-1,:)',2);
    x(i,2:end)=x(i-1,1:end-1);
end
u=x(:,1);
y=u;
  y = a + (b - a)*y;
end