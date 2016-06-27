
const SERVICE = new WeakMap();
const CONFIGSERVICE = new WeakMap();

export default class ContactController {
    constructor(contactService, configValues) {
        this.greetings = 'Hello stranger! Lets become friends';
        this.request = {};

        this.apiResponse = { };

        SERVICE.set(this, contactService);
        CONFIGSERVICE.set(this, configValues);
    };

    sendRequest(isValid) {
        if(isValid){
            this.showLoader = true;
            this.showMessage = false;
            CONFIGSERVICE.get(this).apibase().then((apibase) => {
                SERVICE.get(this).sendRequest(this.request, apibase)
                    .then(
                    (result) => {
                        console.log('id ' + result);

                        this.showLoader = false;
                        this.showMessage = true;

                        this.apiResponse.isSuccess = true;
                        this.apiResponse.msg = 'Success';

                    },
                    (response)=> {
                        this.showLoader = false;
                        this.showMessage = true;

                        this.apiResponse.isSuccess = false;

                        if (response.data == null)
                            this.apiResponse.msg = 'An error occurred';
                        else
                            this.apiResponse.msg = response.data;
                    });
            });
        }
    };
}

