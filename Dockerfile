# Usa la imagen base de Mono
FROM mono:latest

ENV LANG es_ES.UTF-8
ENV LANGUAGE es_ES:es
ENV LC_ALL es_ES.UTF-8
RUN apt-get update && apt-get install -y locales && \
    locale-gen es_ES.UTF-8 && \
    dpkg-reconfigure locales


# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia los archivos de tu proyecto al contenedor
COPY Program.cs .

# Compila la aplicación
RUN mcs -out:AppTiendaV2.exe Program.cs

# Define el comando de inicio para ejecutar la aplicación
CMD ["mono", "AppTiendaV2.exe"]