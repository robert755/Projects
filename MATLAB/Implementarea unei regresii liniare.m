load("lab2_04 (1).mat")
id.X;
id.Y;
val.X;
val.Y;
%plot initial
figure
plot(id.X,id.Y,val.X,val.Y)
n=19;
MSE1=zeros(1,n);
MSE2=zeros(1,n);
for n=1:30

%matricea phi pentru id
N=length(id.X); %nr de puncte din setul de identificare
phi=zeros(N,n);
for i=1:N
    for j=1:n
   phi(i,j)=id.X(i).^(j-1);
   end
end

%tetha pentru id
tetha=phi \ id.Y';

%matricea B=phi.val pt validare
Nval=length(val.X); %nr de puncte din setul de validare
B=zeros(Nval,n);
for i=1:Nval
    for j=1:n
   B(i,j)= val.X(i).^(j-1);
   end
end

%TETA pentru validare
%TETA=B \ val.Y';

y_hat=B*tetha; %y_hat=estimarea validarii
y_id=phi*tetha; %y_id=estimarea identificarii

if n==19
    figure
plot(val.X,val.Y,val.X,y_hat)
title("Validare si aproximare")
end

%MSE pentru identificare
e1=ones(N, 1); %matrice care sa stocheze toate valorile e1
for k=1:N
e1(k)=id.Y(k)-y_id(k);
end
MSE1(n)=1/N*sum(e1.^2);

%MSE pentru validare
e2=ones(Nval, 1); %matrice care sa stocheze toate valorile e2 
for K=1:Nval
e2(K)=val.Y(K)-y_hat(K);
end
MSE2(n)=1/Nval*sum(e2.^2);

[minim,min_gr]=min(MSE2);
end
fprintf('MSE MINIM ESTE IN PUNCTUL:%f \nmin grad%d',min(MSE2),min_gr)
figure
plot(1:n,MSE1)
title("MSE1 id")
figure
plot(1:n,MSE2)
title('MSE2 val')



