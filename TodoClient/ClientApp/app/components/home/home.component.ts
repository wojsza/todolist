import { Component, Inject } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { FormControl } from '@angular/forms';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.style.css']
})

export class HomeComponent {
    
    public name: FormControl = new FormControl();
    public activitieslist: ActivitiesList;
    public status: string;

    constructor(public http: Http, @Inject('BASE_URL') public baseUrl: string)
    {
        this.http.get(this.baseUrl + 'GetAllForecasts').subscribe(result => {
            this.activitieslist = result.json() as ActivitiesList;
        },error => console.error(error));
    }

    submitTask() {

        this.http.post(this.baseUrl + 'PostActivity', { name: this.name.value }).subscribe(result => {

            this.activitieslist.activieties.unshift(result.json() as Activity);
        }, error => console.error(error));
    }

    clearCompleted() {
        let ids: number[] = this.activitieslist.activieties.filter(x => x.isCompleted == true).map(object => object.id);
        let params = new URLSearchParams();
        ids.forEach(id => params.append('id', String(id)));

        this.http.delete(this.baseUrl + "ClearActivity", { params }).subscribe(result => {

            for (let id in ids)
            {
                let removed: Activity = this.activitieslist.activieties.find(val => val.id === Number(id)) as Activity;
                let index: number = this.activitieslist.activieties.indexOf(removed);
                this.activitieslist.activieties.splice(index, 1);
            }
        }, error => console.error(error));
    }

    completeTask(activity: Activity) {
        this.http.put(this.baseUrl + "UpdateActivity", { id: activity.id, name: activity.name, iscompleted: activity.isCompleted }).subscribe();
    }

    statusFilter(filterValue: string) {

        this.status = filterValue;
    }
    
    countCompleted() {
        if (this.activitieslist) {
            return this.activitieslist.activieties.filter(x => x.isCompleted == true).length;
        }
    }

    countActive() {
        if (this.activitieslist) {
            return this.activitieslist.activieties.filter(x => x.isCompleted == false).length;
        }
    }
}


