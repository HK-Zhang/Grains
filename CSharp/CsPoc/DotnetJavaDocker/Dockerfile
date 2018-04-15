FROM microsoft/dotnet:2.0-sdk AS build-env

#RUN \
  #echo oracle-java8-installer shared/accepted-oracle-license-v1-1 select true | debconf-set-selections && \
  #apt-get install software-properties-common
  #add-apt-repository -y ppa:webupd8team/java && \
  #apt-get update && \
  #apt-get install -y oracle-java8-installer && \
  #rm -rf /var/lib/apt/lists/* && \
  #rm -rf /var/cache/oracle-jdk8-installer


  ## Install OpenJDK-8
#RUN apt-get update && \
    #apt-get install -y openjdk-8-jdk && \
    #apt-get install -y ant && \
    #apt-get clean;
#
## Fix certificate issues
#RUN apt-get update && \
    #apt-get install ca-certificates-java && \
    #apt-get clean && \
    #update-ca-certificates -f;
#
## Setup JAVA_HOME -- useful for docker commandline
#ENV JAVA_HOME /usr/lib/jvm/java-8-openjdk-amd64/
#RUN export JAVA_HOME

WORKDIR /app

#ENV JAVA_HOME /usr/lib/jvm/java-8-oracle
#ENV start empty
#ENV end empty

# copy csproj and restore as distinct layers

COPY *.csproj ./
RUN dotnet restore



# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out


# build runtime image
FROM microsoft/dotnet:2.0-runtime 

#RUN \
  #echo oracle-java8-installer shared/accepted-oracle-license-v1-1 select true | debconf-set-selections && \
  #apt-get update && \
  #apt-get install -y software-properties-common && \
  #add-apt-repository -y ppa:webupd8team/java && \
  #apt-get update && \
  #apt-get install -y oracle-java8-installer && \
  #rm -rf /var/lib/apt/lists/* && \
  #rm -rf /var/cache/oracle-jdk8-installer
#

#ENV JAVA_HOME /usr/lib/jvm/java-8-oracle


  # Install OpenJDK-8
RUN apt-get update && \
    apt-get install -y openjdk-8-jdk && \
    apt-get install -y ant && \
    apt-get clean;

# Fix certificate issues
RUN apt-get update && \
    apt-get install ca-certificates-java && \
    apt-get clean && \
    update-ca-certificates -f;

# Setup JAVA_HOME -- useful for docker commandline
ENV JAVA_HOME /usr/lib/jvm/java-8-openjdk-amd64/
RUN export JAVA_HOME

WORKDIR /app


#ENV start empty
#ENV end empty

COPY --from=build-env /app/out ./
COPY --from=build-env /app/Mocker.class ./

ENTRYPOINT ["dotnet", "ViV.Worker.dll"]
