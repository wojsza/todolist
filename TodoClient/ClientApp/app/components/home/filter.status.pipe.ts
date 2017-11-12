import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'status' })

export class StatusPipe implements PipeTransform {
    transform(value: Array<Activity>, completed: string): Array<Activity> {

        let status: boolean;

        switch (completed) {
            case "Active": {
                status = false;
                break;
            }
            case "Completed": {
                status = true;
                break;
            }
            default: {
                return value;
            }
        }

        return value.filter(val => val.isCompleted == status);
    }
}