export interface Event {
  id: number;
  title: string;
  description: string;
  date: string;
  time: string;
  location: string;
  organizer: string;
  category: string;
  attendeesCount: number;
  isOnline: boolean;
  tags: string[];
  status: string;
}
