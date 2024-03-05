%Identificarea unui model Output Error cu optimizare Gauss-Newton
% date motor DC
load('CiceuLab8.mat')

%plot uri initiale
figure;
plot(u)
figure;
plot(vel)

%esantioane pentru id si val
u_id=u(50:350);
y_id=u(50:350);

u_val=u(450:end);
y_val=vel(450:end);

%parametrii initiali
eps=ones(N,1);
b=1;
f=1;
theta_0=[f,b];

% setam pragul de convergenta/iteratii
alpha=0.01;
delta=1e-8; 
lmax=100;
nk=3;
i=0;

while i<lmax
eps(1:nk)=y_id(1:nk);
depsth=zeros(2, N);

for k = nk+1:N
 %Formulele recursive
eps(k)=y_id(k)+f*y_id(k-1)-b*u_id(k-nk)-f*eps(k-1);
depsth(1,k)=-eps(k-1)-f*depsth(1,k-1)+y_id(k-1);
depsth(2,k)=-f*depsth(2,k-1) - u_id(k-nk);
end

%Calculam gradientul
sum_g=zeros(2,1);
 for k=nk+1:N
  sum_g=sum_g+eps(k)*depsth(:,k);
 end
dv_theta=(2/(N-nk))*sum_g;

%Calculam Hessianul
sum_h = zeros(2,2);
 for k = nk+1:N
   sum_h=sum_h+depsth(:,k)*depsth(:,k)';
 end
 H=(2/(N-nk))*sum_h;

 % Metoda Gauss-Newton
theta_next=theta_0-alpha*inv(H)*dv_theta;

%verificam convergenta daca merge 
diff= norm(theta_next - theta_0);
 if diff<=delta
   break; %break inseamna ca este bine convergenta
 end

 %actualizam parametrii
theta_0 = theta_next;
i=i+1; %pana cand atingem lmaxim
end

% Validate the model
OE = idpoly(1, [0, theta(1)], 1, 1, [1, theta(2)], 0, 0.01);

%creez obiectul de tip iddata pt validare
val = iddata(y_val', u_val', 0.01);

figure;
compare(val, OE);

%comparam cele 2 modele lmax trebuie sa fie intre 100-110 ca sa mearga
