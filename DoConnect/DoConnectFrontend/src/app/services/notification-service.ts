import * as signalR from '@microsoft/signalr';

export class NotificationService {
  private hubConnection: signalR.HubConnection;
  private connectedPromise: Promise<void>;
  public hasNewNotifications: boolean = false;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5035/notificationHub')
      .withAutomaticReconnect()
      .build();

    this.connectedPromise = new Promise((resolve) => {
      this.hubConnection
        .start()
        .then(() => {
          console.log('SignalR Connected.');
          resolve();
        })
        .catch((err: any) => console.error('SignalR Connection Error: ', err));
    });
  }

  onNotificationReceived(callback: (user: string, message: string) => void) {
    this.hubConnection.on('ReceiveNotification', callback);
  }

  sendNotification(user: string, message: string) {
    this.hubConnection
      .invoke('SendNotification', user, message)
      .catch((err: any) => console.error(err));
  }

  sendNotificationToUser(userId: string, message: string) {
    this.hubConnection
      .invoke('SendNotificationToUser', userId, message)
      .catch((err: any) => console.error(err));
  }

  sendNotificationToGroup(groupName: string, message: string) {
    this.hubConnection
      .invoke('SendNotificationToGroup', groupName, message)
      .catch((err: any) => console.error(err));
  }

  async joinGroup(groupName: string) {
    await this.connectedPromise;
    console.log('Joining group:', groupName);
    this.hubConnection.invoke('JoinGroup', groupName).catch((err: any) => console.error(err));
  }

  leaveGroup(groupName: string) {
    this.hubConnection.invoke('LeaveGroup', groupName).catch((err: any) => console.error(err));
  }
}

export const notificationService = new NotificationService();
