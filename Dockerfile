# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file and restore any dependencies
WORKDIR /src
COPY MyWebAutomation.sln ./
COPY FrameWorkDesign/*.csproj ./FrameWorkDesign/
COPY LearningWithAbhi/*.csproj ./LearningWithAbhi/
COPY LWASpecflow/*.csproj ./LWASpecflow/
RUN dotnet restore


COPY . .
WORKDIR /src/FrameWorkDesign
RUN dotnet build -c Release -o /app

WORKDIR /src/LearningWithAbhi
RUN dotnet build -c Release -o /app

WORKDIR /src/LWASpecflow
RUN dotnet build -c Release -o /app



# Build the application
#RUN dotnet build -c Release -o out

# Use the official runtime image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the build output
COPY --from=build /app .

# Install Chrome
RUN apt-get update && apt-get install -y wget gnupg2 \
    && wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google-chrome.list' \
    && apt-get update && apt-get install -y google-chrome-stable

# Install ChromeDriver
RUN wget -O /tmp/chromedriver.zip https://chromedriver.storage.googleapis.com/$(curl -sS chromedriver.storage.googleapis.com/LATEST_RELEASE)/chromedriver_linux64.zip \
    && unzip /tmp/chromedriver.zip chromedriver -d /usr/local/bin/

# Set the entry point for the container
ENTRYPOINT ["dotnet", "MyWebAutomation.dll"]